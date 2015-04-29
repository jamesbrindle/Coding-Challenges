package businessLogic;

import java.util.ArrayList;

import com.google.gson.Gson;

import productObjects.Product;

/**
 * Contains methods for anything JSON related
 * 
 * @author Jamie Brindle
 *
 */
public class JSONLogic {

	/**
	 * 
	 * Uses an external library (Gson-2.3.1) to convert an ArrayList to a JSON string.
	 * This method also does some formatting of the string to make it appear as requested.
	 * 
	 * @param productArrayList - The ArrayList of products to convert into a JSON string
	 * @return - The converted JSON string
	 */
	public static String GetJSONString(ArrayList<Product> productArrayList) {

		String jsonStr = new Gson().toJson(productArrayList).replace("\\", "")
				.replace(",", ", ").replace("\":", "\": ")
				.replace(": \" ", ": \"" )
				.replace("\"\"", "\"")
				.replace(", \"ESizeSort\": \"SHOE_EU\"", "")
				.replace(", \"ESizeSort\": \"SHOE_UK\"", "")	
				.replace(", \"ESizeSort\": \"CLOTHING_SHORT\"", "")
				.replace(", \"ESizeSort\": \"OTHER\"", "");

		// extra formatting before return		
		return jsonStr.substring(1, jsonStr.length() - 1);
	}
}
