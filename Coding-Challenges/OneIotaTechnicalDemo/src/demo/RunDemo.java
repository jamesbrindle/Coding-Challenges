package demo;

import java.io.BufferedReader;
import java.io.IOException;
import java.io.InputStreamReader;
import java.util.ArrayList;

import productObjects.Product;
import businessLogic.JSONLogic;
import businessLogic.ProductListLogic;

/**
 * Main program to run
 * 
 * @author Jamie Brindle
 *
 */
public class RunDemo {

	/**
	 * Simple method to make it easier to print a line of text, and easier to
	 * read the procedure
	 * 
	 * @param str
	 *            The string to print
	 */
	private static void Print(String str) {
		System.out.println(str);
	}

	/**
	 * Main entry point to the program.
	 * 
	 * Allows a user to enter the path of a CSV file containing clothing product
	 * data, or defaults to the demo one in the working directory, then runs the
	 * procedures to convert the CSV file into object and into an ArrayList of
	 * Products, in which each product has an array list of sizes. After which
	 * it converts the ArrayList of products into a JSON string and prints it to
	 * screen, while printing step by step statement about what the procedure is doing.
	 * 
	 * @param args
	 * @throws IOException
	 */
	public static void main(String[] args) throws IOException {

		Print("---- Welcome to the OneIota Clothing Product JSONiser! ----");
		Print("");

		Print("Please specifiy the path of the CSV file to convert to JSON, or press "
				+ "the return key to use the demo version in the output folder:");

		BufferedReader buffer = new BufferedReader(new InputStreamReader(
				System.in));
		String csvPath = buffer.readLine();

		if (!csvPath.contains("csv")) {
			csvPath = "./products.csv";
		}

		Print("");

		Print("Importing CSV file and organising products by product listing unit and size...");
		ArrayList<Product> products = ProductListLogic
				.GetSortedProductList(ProductListLogic.ImportCSVFile(csvPath));

		Print("Done");
		Print("");

		Print("Generating and displaying JSON String:");
		Print("");
		
		Print(JSONLogic.GetJSONString(products));

		Print("");
		Print("---- END OF DEMO ----");
	}
}
