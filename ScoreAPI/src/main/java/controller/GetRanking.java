package controller;

import java.io.IOException;
import java.io.PrintWriter;

import javax.servlet.ServletException;
import javax.servlet.annotation.WebServlet;
import javax.servlet.http.HttpServlet;
import javax.servlet.http.HttpServletRequest;
import javax.servlet.http.HttpServletResponse;

import com.google.gson.Gson;

import dao.ScoreDAO;
import model.RankingResult;
import model.Score;

/**
 * Servlet implementation class GetRanking
 */
@WebServlet("/GetRanking")
public class GetRanking extends HttpServlet {
	private static final long serialVersionUID = 1L;
       
    /**
     * @see HttpServlet#HttpServlet()
     */
    public GetRanking() {
        super();
        // TODO Auto-generated constructor stub
    }

	/**
	 * @see HttpServlet#doGet(HttpServletRequest request, HttpServletResponse response)
	 */
    @Override
	protected void doGet(HttpServletRequest request, HttpServletResponse response) throws ServletException, IOException {
    	request.setCharacterEncoding("UTF-8");
    	String score=request.getParameter("score");
    	score=score==null?"0":score;
    	
    	Score s=new Score();
    	s.setScore(Integer.parseInt(score));
    	ScoreDAO dao=new ScoreDAO();
    	
    	RankingResult result=dao.getRankingResult(s);
    	
    	Gson gson=new Gson();
    	response.setContentType("application/json;charset=UTF-8");
    	PrintWriter out=response.getWriter();
    	
    	out.print(gson.toJson(result));

	}

	/**
	 * @see HttpServlet#doPost(HttpServletRequest request, HttpServletResponse response)
	 */
	protected void doPost(HttpServletRequest request, HttpServletResponse response) throws ServletException, IOException {
		// TODO Auto-generated method stub
		doGet(request, response);
	}

}
