package testing;

import java.util.ArrayList;

import productObjects.Product;
import businessLogic.JSONLogic;
import businessLogic.ProductListLogic;

public class Testing {

	public static void main(String[] args) {

		ArrayList<Product> products = ProductListLogic.ImportCSVFile("./products.csv");
		ArrayList<Product> sortedSizeProducts = ProductListLogic.GetSortedProductList(products);
		JSONLogic.GetJSONString(sortedSizeProducts);
	}	
}
