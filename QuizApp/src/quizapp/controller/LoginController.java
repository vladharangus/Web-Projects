package quizapp.controller;

import quizapp.domain.User;
import quizapp.model.DBManager;
import javax.servlet.RequestDispatcher;
import javax.servlet.ServletException;
import javax.servlet.http.HttpServlet;
import javax.servlet.http.HttpServletRequest;
import javax.servlet.http.HttpServletResponse;
import javax.servlet.http.HttpSession;
import java.io.IOException;
import java.io.PrintWriter;
import java.util.ArrayList;

public class LoginController extends HttpServlet {

    public LoginController() {super();}

    protected void doPost(HttpServletRequest request,
                          HttpServletResponse response) throws ServletException, IOException {

        String username = request.getParameter("username");
        String password = request.getParameter("password");
        int questionsNumber = Integer.parseInt(request.getParameter("questionsNumber"));
        int questionsNumberPage = Integer.parseInt(request.getParameter("questionsNumberPage"));
        RequestDispatcher requestDispatcher = null;
        DBManager dbManager = new DBManager();
        User user = dbManager.authenticate(username, password);

        if (user != null) {
            requestDispatcher = request.getRequestDispatcher("/quizPage.jsp");
            HttpSession session = request.getSession();
            session.setAttribute("user", user);
            session.setAttribute("totalQuestions", questionsNumber);
            session.setAttribute("pageQuestions", questionsNumberPage);
            int pq = 1 - Integer.parseInt(session.getAttribute("pageQuestions").toString());
            session.setAttribute("currentIndex", 1);
        } else {
            requestDispatcher = request.getRequestDispatcher("/error.jsp");
        }
        requestDispatcher.forward(request, response);
    }
    protected void doGet(HttpServletRequest request,
                          HttpServletResponse response) throws ServletException, IOException {
        String action = request.getParameter("action");
        if ((action != null) && action.equals("answer")) {

            int id = Integer.parseInt(request.getParameter("id"));
            int userid = Integer.parseInt(request.getParameter("userid"));
            String  answer = request.getParameter("answer");
            DBManager dbManager = new DBManager();
            boolean result = dbManager.answerQuestion(userid, id, answer);
            PrintWriter out = new PrintWriter(response.getOutputStream());
            String verdict = "";
            HttpSession session = request.getSession();
            User user = (User) session.getAttribute("user");
            if(result){
                verdict = "your answer is correct :)";
                user.setCurrentScore(user.getCurrentScore() + 1);
                session.setAttribute("user", user);
            }
            else {
                verdict = "your answer is wrong :(";
            }
            out.println(verdict);
            out.flush();
        } else if ((action != null) && action.equals("finish")) {
            int userid = Integer.parseInt(request.getParameter("userid"));
            DBManager dbManager = new DBManager();
            ArrayList<Integer> result = dbManager.finish(userid);
            String finalResults = "Your score is: " + result.get(0) + " Your highscore is: " + result.get(1);
            PrintWriter out = new PrintWriter(response.getOutputStream());
            out.println(finalResults);
            out.flush();
        } else if ((action != null) && action.equals("logout")) {
            RequestDispatcher requestDispatcher;
            requestDispatcher = request.getRequestDispatcher("/index.html");
            HttpSession session = request.getSession();
            session.invalidate();
            requestDispatcher.forward(request, response);
        }
    }

}
