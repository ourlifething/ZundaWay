package model;

import java.io.Serializable;

public class Score implements Serializable{
	private int id;
	private int score;
public Score() {
}
public int getId() {
	return id;
}
public int getScore() {
	return score;
}
public void setId(int id) {
	this.id=id;
}
public void setScore(int score) {
	this.score=score;
}
}
