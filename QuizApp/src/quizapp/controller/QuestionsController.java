package quizapp.controller;

import netscape.javascript.JSObject;
import org.json.simple.JSONArray;
import org.json.simple.JSONObject;
import quizapp.domain.Question;
import quizapp.model.DBManager;


import javax.servlet.ServletException;
import javax.servlet.http.HttpServlet;
import javax.servlet.http.HttpServletRequest;
import javax.servlet.http.HttpServletResponse;
import javax.servlet.http.HttpSession;
import java.io.IOException;
import java.io.PrintWriter;
import java.util.ArrayList;

public class  QuestionsController extends HttpServlet {
    protected void doGet(HttpServletRequest request, HttpServletResponse response) throws ServletException, IOException {
        String action = request.getParameter("action");
        if ((action != null) && action.equals("getAll")) {
            int currentIndex = Integer.parseInt(request.getParameter("currentIndex"));
            int perPage = Integer.parseInt(request.getParameter("perPage"));
            int total = Integer.parseInt(request.getParameter("total"));
            response.setContentType("application/json");
            DBManager dbManager = new DBManager();
            ArrayList<Question> questions = dbManager.getQuestions(currentIndex, perPage, total);
            JSONArray jsonQuestions = new JSONArray();
            for (Question question : questions) {
                JSONObject jsonObject = new JSONObject();
                jsonObject.put("id", question.getId());
                jsonObject.put("text", question.getText());
                jsonObject.put("possibleAnswers", question.getPossibleAnswers());
                jsonQuestions.add(jsonObject);
            }
            PrintWriter out = new PrintWriter(response.getOutputStream());
            out.println(jsonQuestions.toJSONString());
            out.flush();
        }
    }

    protected void doPost(HttpServletRequest request, HttpServletResponse response) throws ServletException, IOException {

    }

}
