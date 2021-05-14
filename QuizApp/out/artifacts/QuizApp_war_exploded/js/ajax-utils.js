function getQuestions(currentIndex, perPage, total, callbackFunction) {
    $.getJSON(
        "QuestionsController",
        {action: 'getAll',
        currentIndex:  currentIndex,
        perPage: perPage,
        total: total},
        callbackFunction
    );
}

function answerQuestion(userid, id, answer, callbackFunction) {
    $.get("LoginController",
        { action: 'answer',
          userid: userid,
          id: id,
          answer: answer
        },
        callbackFunction
    );
}

function finish(userid, callbackFunction) {
    $.get("LoginController",
        { action: 'finish',
            userid: userid
        },
        callbackFunction
    );
}

function logout() {
    $.get("LoginController",
        {
            action: 'logout',
        }
    );

}