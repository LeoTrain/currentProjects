#include <unistd.h>

void ft_print_comb(void)
{
    char a = 47;
    char b = a + 1;
    char c = b + 1;

    while (a < '7')
    {
        a += 1;
        b = a;
        while (b < '8')
        {
            b += 1;
            c = b;
            while (c < '9')
            {
                c += 1;
                write(1, &a, 1);
                write(1, &b, 1);
                write(1, &c, 1);
                if (a != '7')
                {
                    write(1, ", ", 2);
                }
            }
        }
    }
    
}
