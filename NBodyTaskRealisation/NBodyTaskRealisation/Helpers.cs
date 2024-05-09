namespace NBodyTaskRealisation;

public static class Helpers
{
    public static int[][] GetRanges(int startNum, int endNum, int rangesNum)
    {

        // Вычисление размера каждого диапазона
        int rangeSize = (endNum - startNum + 1) / rangesNum;

        // Массив для хранения диапазонов
        int[][] ranges = new int[rangesNum][];

        // Заполнение массива диапазонов
        int currentStart = startNum;
        for (int i = 0; i < rangesNum; i++)
        {
            int currentEnd = currentStart + rangeSize - 1;
            // Учтем остаток при делении
            if (i == rangesNum - 1)
            {
                currentEnd += (endNum - startNum + 1) % rangesNum;
            }
            ranges[i] = new int[] { currentStart, currentEnd };
            currentStart = currentEnd + 1;
        }
        return ranges;
    }
}