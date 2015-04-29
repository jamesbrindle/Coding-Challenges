package businessLogic;

import java.io.BufferedReader;
import java.io.FileNotFoundException;
import java.io.FileReader;
import java.io.IOException;
import java.util.ArrayList;

import productObjects.ClothingShort;
import productObjects.Product;
import productObjects.ProductOther;
import productObjects.ShoeEU;
import productObjects.ShoeUK;
import productObjects.SizeSort;
import productObjects.SizeSort.SizeSortEnum;

/**
 * Contains methods for anything product list related
 * 
 * @author Jamie Brindle
 *
 */
public class ProductListLogic {

	/**
	 * Reads a CSV file, and then line by line splits it and creates a product object with corresponding properties and sizes.
	 * A product can have more than one size, so this is stored as an array list object for each product.
	 * 
	 * The product is grouped by its PLU. Each PLU with have a specific SizeSort enum and type assigned to it, so the same method name
	 * can be used with different implementations for type of size (Polymorphism).
	 * 
	 * @param csvPath The file path to the CSV file
	 * @return an array list of products
	 */
	public static ArrayList<Product> ImportCSVFile(String csvPath) {

		BufferedReader br = null;
		String line = "";
		String cvsSplitBy = ",";

		ArrayList<Product> productList = new ArrayList<Product>();

		try {

			br = new BufferedReader(new FileReader(csvPath));
			while ((line = br.readLine()) != null) {
				String[] productData = line.split(cvsSplitBy);

				// First 'if' - when the product array list is empty
				if (productList.size() == 0) {
					Product product = new Product(productData[1],
							productData[2]);
					product.sizes = new ArrayList<SizeSort>();
					SizeSort size;

					if (productData[4].equalsIgnoreCase("SHOE_UK")
							|| productData[4].equalsIgnoreCase(" SHOE_UK")) {
						size = new ShoeUK();
						size.ESizeSort = SizeSortEnum.SHOE_UK;
						size.SKU = productData[0];
						size.size = productData[3];
						
					} else if (productData[4].equalsIgnoreCase("SHOE_EU")
							|| productData[4].equalsIgnoreCase(" SHOE_EU")) {
						size = new ShoeEU();
						size.ESizeSort = SizeSortEnum.SHOE_EU;
						size.SKU = productData[0];
						size.size = productData[3];
						
					} else if (productData[4]
							.equalsIgnoreCase("CLOTHING_SHORT")
							|| productData[4]
									.equalsIgnoreCase(" CLOTHING_SHORT")) {
						size = new ClothingShort();
						size.ESizeSort = SizeSortEnum.CLOTHING_SHORT;
						size.SKU = productData[0];
						size.size = productData[3];
						
					} else {
						size = new ProductOther();
						size.ESizeSort = SizeSortEnum.OTHER;
						size.SKU = productData[0];
						size.size = productData[3];
					}

					product.sizes.add(size);
					productList.add(product);
					
				// If the array list isn't empty, we first need to iterate through the current list to check if an object exists
			    // with the same PLU. If it does, simply add the new size to the list, otherwise create a new list along with its size
				} else {
					boolean pluExists = false;

					for (int i = 0; i < productList.size(); i++) {
						if (productList.get(i).PLU.equals(productData[1])) {
							SizeSort size;

							if (productData[4].equalsIgnoreCase("SHOE_UK")
									|| productData[4]
											.equalsIgnoreCase(" SHOE_UK")) {
								size = new ShoeUK();
								size.ESizeSort = SizeSortEnum.SHOE_UK;
								size.SKU = productData[0];
								size.size = productData[3];
								
							} else if (productData[4]
									.equalsIgnoreCase("SHOE_EU")
									|| productData[4]
											.equalsIgnoreCase(" SHOE_EU")) {
								size = new ShoeEU();
								size.ESizeSort = SizeSortEnum.SHOE_EU;
								size.SKU = productData[0];
								size.size = productData[3];
								
							} else if (productData[4]
									.equalsIgnoreCase("CLOTHING_SHORT")
									|| productData[4]
											.equalsIgnoreCase(" CLOTHING_SHORT")) {
								size = new ClothingShort();
								size.ESizeSort = SizeSortEnum.CLOTHING_SHORT;
								size.SKU = productData[0];
								size.size = productData[3];
								
							} else {
								size = new ProductOther();
								size.ESizeSort = SizeSortEnum.OTHER;
								size.SKU = productData[0];
								size.size = productData[3];
							}

							productList.get(i).sizes.add(size);

							pluExists = true;
							break;
						}
					}

					//Otherwise create a new list along with its size
					if (!pluExists) {
						Product product = new Product(productData[1],
								productData[2]);
						product.sizes = new ArrayList<SizeSort>();
						SizeSort size;
						if (productData[4].equalsIgnoreCase("SHOE_UK")
								|| productData[4].equalsIgnoreCase(" SHOE_UK")) {
							size = new ShoeUK();
							size.ESizeSort = SizeSortEnum.SHOE_UK;
							size.SKU = productData[0];
							size.size = productData[3];
							
						} else if (productData[4].equalsIgnoreCase("SHOE_EU")
								|| productData[4].equalsIgnoreCase(" SHOE_EU")) {
							size = new ShoeEU();
							size.ESizeSort = SizeSortEnum.SHOE_EU;
							size.SKU = productData[0];
							size.size = productData[3];
							
						} else if (productData[4]
								.equalsIgnoreCase("CLOTHING_SHORT")
								|| productData[4]
										.equalsIgnoreCase(" CLOTHING_SHORT")) {
							size = new ClothingShort();
							size.ESizeSort = SizeSortEnum.CLOTHING_SHORT;
							size.SKU = productData[0];
							size.size = productData[3];
							
						} else {
							size = new ProductOther();
							size.ESizeSort = SizeSortEnum.OTHER;
							size.SKU = productData[0];
							size.size = productData[3];
						}

						product.sizes.add(size);
						productList.add(product);
					}
				}
			}
		} catch (FileNotFoundException e) {
			System.out.println("FileNotFoundException: " + e.getMessage());
			
			// Exit program. Won't be able to continue anyway
			System.exit(0);

		} catch (IOException e) {
			System.out.println("IOException: " + e.getMessage());
			
			// Exit program. Won't be able to continue anyway
			System.exit(0);

		} finally {
			
			// Try and close the bufferedReader
			if (br != null) {
				try {
					br.close();
				} catch (IOException e) {
					e.printStackTrace();
				}
			}
		}

		return productList;
	}

	/**
	 * Sorts each products size Array list depending on it's corresponding SizeSort type
	 * 
	 * @param productArrayList The unsorted product array list
	 * @return The sorted product array list
	 */
	public static ArrayList<Product> GetSortedProductList(
			ArrayList<Product> productArrayList) {

		for (Product product : productArrayList) {
			switch (product.sizes.get(0).ESizeSort) {
			case SHOE_UK:
				product.sizes = ShoeUK.GetSortedSizes(product.sizes);
				break;
			case SHOE_EU:
				product.sizes = ShoeEU.GetSortedSizes(product.sizes);
				break;
			case CLOTHING_SHORT:
				product.sizes = ClothingShort.GetSortedSizes(product.sizes);
				break;
			default:
				product.sizes = ProductOther.GetSortedSizes(product.sizes);
				break;
			}
		}

		return productArrayList;
	}
}
