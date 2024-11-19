#include <unistd.h>

void ft_print_numbers(void)
{
    int start = 48;
    int end = 57;
    for (int i = start; i <= end; i++)
    {
        write(1, &i, 1);
    }
}
