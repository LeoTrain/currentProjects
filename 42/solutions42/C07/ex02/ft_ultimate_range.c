#include <stdlib.h>

int ft_ultimate_range(int **range, int min, int max)
{
    if (min >= max)
    {
        *range = NULL;
        return 0;
    }

    int size = max - min;   
    *range = (int*)malloc(size * 4);
    if (*range == NULL)
        return -1;

    for (int i = 0; i < size; i++)
        (*range)[i] = min + i;
    return max - min;
}
