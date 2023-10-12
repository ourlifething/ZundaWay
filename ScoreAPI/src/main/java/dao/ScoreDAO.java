package dao;

import java.sql.Connection;
import java.sql.PreparedStatement;
import java.sql.ResultSet;
import java.sql.SQLException;
import java.sql.Statement;
import java.util.ArrayList;
import java.util.List;

import javax.naming.Context;
import javax.naming.InitialContext;
import javax.naming.NamingException;
import javax.sql.DataSource;

import model.RankingResult;
import model.Score;

public class ScoreDAO {
	private Connection db;
	private PreparedStatement ps;
	private ResultSet rs;

private void connect() throws NamingException,SQLException {
	Context context = new InitialContext();
	DataSource ds = (DataSource) context.lookup("java:comp/env/jdbc/jsp");
	this.db = ds.getConnection();
	}

private void disconnect() {
	try {
		if (rs!=null) {
		rs.close();
		}
		if (ps!=null) {
			ps.close();
		}
		if (db!=null) {
			db.close();
		}
		} catch (SQLException e) {
		// TODO 自動生成された catch ブロック
		e.printStackTrace();
	}}
public void insertOne(Score score) {
	try {
		this.connect();
		ps=db.prepareStatement("INSERT INTO scores(score) VALUES(?)");
		ps.setInt(1,score.getScore());
		ps.executeUpdate();
		
		} catch (NamingException | SQLException e) {
		// TODO 自動生成された catch ブロック
		e.printStackTrace();
	}finally {
		this.disconnect();
	}
}
public void insertAll(List<Score> list) {
	try {
		this.connect();
		db.setAutoCommit(false);
		ps=db.prepareStatement("INSERT INTO scores(score) VALUES(?)");
		for(Score score:list) {
			ps.setInt(1, score.getScore());
			ps.executeUpdate();
		}
		db.commit();
	} catch (NamingException | SQLException e) {
		// TODO 自動生成された catch ブロック
		e.printStackTrace();
	}finally {
		this.disconnect();
	}
}
public List<Score> find(int num){
	List<Score> list=new ArrayList<>();
	try {
		this.connect();
		ps=db.prepareStatement("SELECT *FROM scores ORDER BY score DESC LIMIT ?");
		ps.setInt(1, num);
		rs=ps.executeQuery();
		while(rs.next()) {
			Score score=new Score();
			score.setId(rs.getInt("id"));
			score.setScore(rs.getInt("score"));
			list.add(score);
		}
	} catch (NamingException | SQLException e) {
		// TODO 自動生成された catch ブロック
		e.printStackTrace();
	}finally {
		this.disconnect();
	}
	return list;
}
public RankingResult getRankingResult(Score score) {
	RankingResult result=new RankingResult();
	try {
		this.connect();
		ps=db.prepareStatement("INSERT INTO scores(score) VALUES(?)",Statement.RETURN_GENERATED_KEYS);
		ps.setInt(1, score.getScore());
		ps.executeUpdate();
		
		rs=ps.getGeneratedKeys();
		if(rs.next()) {
			result.setLastId(rs.getInt(1));
		}
		
		ps=db.prepareStatement("SELECT COUNT(*)+1 AS rank FROM scores WHERE score > ?");
		ps.setInt(1,score.getScore());
		rs=ps.executeQuery();
		if(rs.next()) {
			result.setRank(rs.getInt("rank"));
		}
		
		ps=db.prepareStatement("SELECT COUNT(*)+1 AS rankIn FROM scores WHERE score >= ?");
		ps.setInt(1,score.getScore());
		rs=ps.executeQuery();
		if(rs.next()) {
			result.setRankIn(rs.getInt("rankIn"));
		}

	} catch (NamingException | SQLException e) {
		// TODO 自動生成された catch ブロック
		e.printStackTrace();
	}finally {
		this.disconnect();
	}
	return result;
	}
}


