package productObjects;

/**
 * 
 * Base class for the SizeSort type
 * 
 * @author Jamie Brindle
 *
 */
public abstract class SizeSort {
	public enum SizeSortEnum {
		SHOE_UK,
		SHOE_EU,
		CLOTHING_SHORT,
		OTHER
	}	
	
	public String SKU;
	public String size;	
	public SizeSortEnum ESizeSort;
}
