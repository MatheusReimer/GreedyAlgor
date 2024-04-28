namespace FractionalKnapsackProblem {
    public class FractionalKnapsack {
        public static double MaxValue(int[] values, int[] weights, int capacity) {
            // Calculate value per unit weight for each item
            double[] valuePerUnitWeight = new double[values.Length];
            for (int i = 0; i < values.Length; i++) {
                valuePerUnitWeight[i] = (double)values[i] / weights[i];
            }

            double totalValue = 0;

            while (capacity > 0) {
                // Find item with maximum value per unit weight
                int maxIndex = -1;
                double maxValuePerUnitWeight = 0;
                for (int i = 0; i < values.Length; i++) {
                    if (weights[i] > 0 && valuePerUnitWeight[i] > maxValuePerUnitWeight) {
                        maxIndex = i;
                        maxValuePerUnitWeight = valuePerUnitWeight[i];
                    }
                }

                // If no items are left or capacity is 0, break
                if (maxIndex == -1 || capacity == 0)
                    break;

                // Take fraction of the item if necessary
                double fraction = Math.Min(weights[maxIndex], capacity);
                totalValue += fraction * valuePerUnitWeight[maxIndex];
                weights[maxIndex] -= (int)fraction;
                capacity -= (int)fraction;
            }

            return totalValue;
        }
    }
}
