package productObjects;

import java.util.ArrayList;
import java.util.Collections;
import java.util.Comparator;

/**
 * 
 * Extends the SizeSort class for a different means to sort the size of its particular size type
 * smallest to largest.
 * 
 * @author Jamie Brindle
 *
 */
public class ShoeUK extends SizeSort {

	/**
	 * Sorts a ShoeUK SizeSort type sizes ArrayList
	 * 
	 * Uses the Collection.Sort library to compare
	 * 
	 * @param sizeArrayList Given sizes array list
	 * @return sorted sizes array list (smallest to largest)
	 */
	public static ArrayList<SizeSort> GetSortedSizes(
			ArrayList<SizeSort> sizeArrayList) {

		ArrayList<SizeSort> childSizes = new ArrayList<SizeSort>();
		ArrayList<SizeSort> adultSizes = new ArrayList<SizeSort>();

		for (SizeSort size : sizeArrayList) {
			if (size.size.contains("Child") || size.size.contains("child")) {
				childSizes.add(size);
			} else {
				adultSizes.add(size);
			}
		}

		Collections.sort(childSizes, new Comparator<SizeSort>() {
			public int compare(SizeSort s1, SizeSort s2) {
				return s1.size.compareToIgnoreCase(s2.size);
			}
		});

		Collections.sort(adultSizes, new Comparator<SizeSort>() {
			public int compare(SizeSort s1, SizeSort s2) {
				return s1.size.compareToIgnoreCase(s2.size);
			}
		});

		sizeArrayList.clear();
		sizeArrayList.addAll(childSizes);
		sizeArrayList.addAll(adultSizes);

		return sizeArrayList;
	}
}
