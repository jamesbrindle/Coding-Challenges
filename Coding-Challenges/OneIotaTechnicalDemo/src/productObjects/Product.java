package productObjects;

import java.util.ArrayList;

/**
 * 
 * A 'Product' object, containing the data for each product and an array list of sizes
 * 
 * @author Jamie Brindle
 *
 */
public class Product {
	
	public String PLU;
	public String Name;
	public ArrayList<SizeSort> sizes;

	/**
	 * Strict constructor
	 * 
	 */
	public Product(String plu, String name) {
		this.PLU = plu;
		this.Name = name;
	}
}


