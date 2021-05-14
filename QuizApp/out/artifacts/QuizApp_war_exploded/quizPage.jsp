<%@ page import="quizapp.domain.User" %><%--
  Created by IntelliJ IDEA.
  User: Vlad
  Date: 5/19/2020
  Time: 5:21 PM
  To change this template use File | Settings | File Templates.
--%>
<%@ page contentType="text/html;charset=UTF-8" language="java" %>
<html>
<head>
    <link rel="stylesheet" href="style.css">
    <meta http-equiv="Content-Type" content="text/html; charset=UTF-8">
    <title>Quiz</title>
    <script src="js/jquery-3.4.1.js"></script>
    <script src="js/ajax-utils.js"></script>
</head>
<body>
<%! User user;
    public int increment(int a, int b){
        return a + b;
    }
    int perPage;
%>
<%  user = (User) session.getAttribute("user");
    if (user != null) {
        out.println("Welcome " + user.getUsername());
    }
    perPage = Integer.parseInt(session.getAttribute("pageQuestions").toString());
%>
    <button id = "lgout" type="button">Logout</button>
    <br/>
    <div id = "page" style="visibility: hidden">1</div>
    <br/>
    <section><table id = "question-table"></table></section>
    <p><button id = "getQuestionsbtn" type="button">Next Question</button></p>
    Enter the id of the question : <input type="text" name="questionId" id = "questionId">
    Enter your answer : <input type="text" name="answer" id = "answer">
    <button id = "answerbtn" type="button">Submit your answer</button>
    <div id = "score" ></div>
    <button id = "finish" type="button">Finish</button>
    <div id = "result"></div>
    <script>``
        $(document).ready(function () {
            $("#getQuestionsbtn").click(function () {
                var page = parseInt(document.getElementById("page").innerHTML);
                getQuestions(page, <%=perPage%>, <%=session.getAttribute("totalQuestions")%>, function (questions)  {
                    console.log(questions);
                    $("#question-table").html("");
                    $("#question-table").append("<tr><td>Id</td><td>Text</td><td>Possible Answers</td></tr>");
                    for (var name in questions) {
                        $("#question-table").append("<tr><td class='question-name'>"+questions[name].id+"</td>" +
                            "<td>"+questions[name].text+"</td>" +
                            "<td>"+questions[name].possibleAnswers+"</td>" )
                    }

                })
                page = page+ <%=perPage%>;
                $("#page").html("");
                $("#page").append(page)
                $("#page").hide();
            })

            $("#answerbtn").click(function() {
                answerQuestion(<%=user.getId()%>,
                    document.getElementById("questionId").value,
                    document.getElementById("answer").value,
                    function(response) {
                        $("#score").html("");
                        $("#score").append(response);
                    }
                )
            })

            $("#finish").click(function() {
                finish(<%=user.getId()%>,
                    function(response) {
                        $("#result").html("");
                        $("#result").append(response);
                    }
                )
            })

            $("#lgout").click(function() {
                logout()
            })

        });
    </script>
</body>
</html>
