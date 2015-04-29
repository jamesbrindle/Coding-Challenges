package productObjects;

import java.util.ArrayList;

/**
 * 
 * Extends the SizeSort class for a different means to sort the size of its particular size type
 * smallest to largest.
 * 
 * @author Jamie Brindle
 *
 */
public class ClothingShort extends SizeSort {

	/**
	 * Sorts a ClothingShort SizeSort type sizes ArrayList
	 * 
	 * Loops through the array list multiple times adding sizes to another array list in the correct order
	 * 
	 * @param sizeArrayList Given sizes array list
	 * @return sorted sizes array list (smallest to largest)
	 */
	public static ArrayList<SizeSort> GetSortedSizes(
			ArrayList<SizeSort> sizeArrayList) {

		ArrayList<SizeSort> sortedSizes = new ArrayList<SizeSort>();
		
		for (SizeSort size : sizeArrayList) {
			if (size.size.equalsIgnoreCase(" \"XXS\"")) {
				sortedSizes.add(size);
				break;
			}
		}
		for (SizeSort size : sizeArrayList) {
			if (size.size.equalsIgnoreCase(" \"XS\"")) {
				sortedSizes.add(size);
				break;
			}
		}
		for (SizeSort size : sizeArrayList) {
			if (size.size.equalsIgnoreCase(" \"S\"")) {
				sortedSizes.add(size);
				break;
			}
		}
		for (SizeSort size : sizeArrayList) {
			if (size.size.equalsIgnoreCase(" \"M\"")) {
				sortedSizes.add(size);
				break;
			}
		}
		for (SizeSort size : sizeArrayList) {
			if (size.size.equalsIgnoreCase(" \"L\"")) {
				sortedSizes.add(size);
				break;
			}
		}
		for (SizeSort size : sizeArrayList) {
			if (size.size.equalsIgnoreCase(" \"XL\"")) {
				sortedSizes.add(size);
				break;
			}
		}
		for (SizeSort size : sizeArrayList) {
			if (size.size.equalsIgnoreCase(" \"XXL\"")) {
				sortedSizes.add(size);
				break;
			}
		}
		for (SizeSort size : sizeArrayList) {
			if (size.size.equalsIgnoreCase(" \"XXXL\"")) {
				sortedSizes.add(size);
				break;
			}
		}
		for (SizeSort size : sizeArrayList) {
			if (size.size.equalsIgnoreCase(" \"XXXXL\"")) {
				sortedSizes.add(size);
				break;
			}
		}
		
		// Anything else that we mist
		for (SizeSort size : sizeArrayList) {
			if (!size.size.equalsIgnoreCase(" \"XXXXL\"")
					&& !size.size.equalsIgnoreCase(" \"XS\"")
					&& !size.size.equalsIgnoreCase(" \"XXS\"")
					&& !size.size.equalsIgnoreCase(" \"XXXL\"")
					&& !size.size.equalsIgnoreCase(" \"XXL\"")
					&& !size.size.equalsIgnoreCase(" \"XL\"")
					&& !size.size.equalsIgnoreCase(" \"L\"")
					&& !size.size.equalsIgnoreCase(" \"M\"")
					&& !size.size.equalsIgnoreCase(" \"S\"")) {
				sortedSizes.add(size);
			}
		}

		return sortedSizes;
	}
}
