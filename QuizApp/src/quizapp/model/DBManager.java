package quizapp.model;

import quizapp.domain.Question;
import quizapp.domain.User;

import javax.servlet.http.HttpSession;
import java.sql.*;
import java.util.ArrayList;

public class DBManager {
    private Statement stmt;

    public DBManager() {connect();}

    public  void connect () {
        try {
            Class.forName(Driver.class.getName());
            Connection con = DriverManager.getConnection("jdbc:postgresql://localhost:5432/quiz", "postgres", "1234");
            stmt = con.createStatement();

        }catch (Exception ex) {
            System.out.println("eroare la connect:"+ex.getMessage());
            ex.printStackTrace();
        }
    }

    public User authenticate(String username, String password) {
        ResultSet rs;
        User user = null;
        //System.out.println(username + " " + password);
        try {
            rs = stmt.executeQuery("select * from users where username = '" + username + "' and password = '" + password + "'");
            if (rs.next()) {
                user = new User(rs.getInt("id"), rs.getString("username"), rs.getString("password"), rs.getInt("highscore"));
                //System.out.println(user.getId() + " " + user.getUsername() + " " + user.getPassword());
                int update  = stmt.executeUpdate("update users set score = 0 where id = '" + user.getId() + "'");
            }
            rs.close();
        } catch (SQLException throwables) {
            throwables.printStackTrace();
        }
        return user;
    }

    public ArrayList<Question> getQuestions(int currentIndex, int perPage, int total) {
        ArrayList<Question> questions = new ArrayList<>();
        ResultSet rs;

        if (currentIndex > total)
            currentIndex = total - perPage + 1;

        try {
            int limit = currentIndex + perPage;
            rs = stmt.executeQuery("select * from questions where id >= '" + currentIndex + "' and id < '" + limit + "'");
            while (rs.next()) {
                Question q = new Question(
                        rs.getInt("id"),
                        rs.getString("text"),
                        rs.getString("possibleAnswers"),
                        rs.getString("answer")
                );
                questions.add(q);
            }
            rs.close();
        }catch (SQLException e) {
            e.printStackTrace();
        }
        return questions;
    }

    public boolean answerQuestion(int userid, int id, String answer) {
        ResultSet rs;
        String answerList = "";
        try {
            rs = stmt.executeQuery("select * from questions where id = '" + id + "'");
            if (rs.next()) {
                answerList = rs.getString("possibleAnswers");
            }
            rs.close();
        } catch (SQLException throwables) {
            throwables.printStackTrace();
        }
       if(answerList.contains(answer)) {
           try {
               int currentScore = 1;
               int highscore = 0;
               rs = stmt.executeQuery("select score, highscore from users where id = '" + userid + "'");
               if (rs.next()) {
                   currentScore += rs.getInt("score");
                   highscore = rs.getInt("highscore");
               }
               rs.close();
               int update;
               if(currentScore > highscore) {
                   update  = stmt.executeUpdate("update users  set score = " + currentScore + ", highscore = " + currentScore + " where id = '" + userid + "'");
               }
               else update  = stmt.executeUpdate("update users  set score = " + currentScore + " where id = '" + userid + "'");
           } catch (SQLException throwables) {
               throwables.printStackTrace();
           }
       }
        return answerList.contains(answer);
    }

    public ArrayList<Integer> finish(int userid) {
        ArrayList<Integer> result = new ArrayList<>();
        ResultSet rs;
        try {
            rs = stmt.executeQuery("select score, highscore from users where id = '" + userid + "'");
            if (rs.next()) {
                result.add(rs.getInt("score"));
                result.add(rs.getInt("highscore"));
            }
            rs.close();
        } catch (SQLException throwables) {
            throwables.printStackTrace();
        }
        return result;
    }
}

