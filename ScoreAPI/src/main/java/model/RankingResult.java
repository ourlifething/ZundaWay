package model;

import java.io.Serializable;

public class RankingResult implements Serializable{
	private int lastId;//最後に挿入したデータのID
	private int rank;//最後に総集したデータの順位
	private int rankIn;//同一順位を含めた人数 
	
	public RankingResult() {}

	public int getLastId() {
		return lastId;
	}

	public void setLastId(int lastId) {
		this.lastId = lastId;
	}

	public int getRank() {
		return rank;
	}

	public void setRank(int rank) {
		this.rank = rank;
	}

	public int getRankIn() {
		return rankIn;
	}

	public void setRankIn(int rankIn) {
		this.rankIn = rankIn;
	}

	
	

}
