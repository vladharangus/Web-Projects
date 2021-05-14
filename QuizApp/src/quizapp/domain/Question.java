package quizapp.domain;

public class Question {

    private int id;
    private String text;
    private String possibleAnswers;
    private String answer;

    public int getId() {
        return id;
    }

    public void setId(int id) {
        this.id = id;
    }

    public String getText() {
        return text;
    }

    public void setText(String text) {
        this.text = text;
    }

    public String getPossibleAnswers() {
        return possibleAnswers;
    }

    public void setPossibleAnswers(String possibleAnswers) {
        this.possibleAnswers = possibleAnswers;
    }

    public String getAnswer() {
        return answer;
    }

    public void setAnswer(String answer) {
        this.answer = answer;
    }


    public Question(int id, String text, String possibleAnswers, String answer) {
        this.id = id;
        this.text = text;
        this.possibleAnswers = possibleAnswers;
        this.answer = answer;
    }
}
