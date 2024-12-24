#include <unistd.h>

void ft_print_alphabet(void)
{
    int first = 97;
    int last = 122;
    for (int i = first; i <= last; i++)
    {
        write(1, &i, 1);
    }
}
