#include <unistd.h>

void ft_print_reverse_alphabet(void)
{
    int first = 122;
    int last = 97;
    for (int i = first; i >= last; i--)
    {
        write(1, &i, 1);
    }
}
