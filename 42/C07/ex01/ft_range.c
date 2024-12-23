#include <stdlib.h>

int *ft_range(int min, int max)
{
    if (min >= max)
        return NULL;
    int range_length = max - min;
    int *range = malloc(range_length * 1);
    for (int i = 0; i < range_length; i++)
        range[i] = min + i;
    return range;
}
