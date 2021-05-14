<%--
  Created by IntelliJ IDEA.
  User: Vlad
  Date: 5/19/2020
  Time: 5:21 PM
  To change this template use File | Settings | File Templates.
--%>
<%@ page contentType="text/html;charset=UTF-8" language="java" %>
<html>
<head>
    <title>Log in</title>
    <script>alert("Invalid Credentials")</script>
    <style>
        form {
            margin-left: auto;
            margin-right: auto;
            width: 400px;
        }
    </style>
</head>
<body>
Login failed!
<form action="LoginController" method="post">
    Enter username : <input type="text" name="username"> <BR>
    Enter password : <input type="password" name="password"> <BR>
    Enter number of questions :  <input type="number" name="questionsNumber"> <BR>
    Enter number of questions on a page :  <input type="number" name="questionsNumberPage"> <BR>
    <input type="submit" value="Login"/>
</form>
</body>
</html>
