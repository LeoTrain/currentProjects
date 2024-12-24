#include <unistd.h>


void ft_putnbr(int nb)
{
    if (nb < 0)
    {
        if (nb == -2147483648)
        {
            write(1, "-2", 2);
            nb = 147483648;
        }
        else 
        {
            write(1, "-", 1);
            nb = -nb;
        }
    }

    if (nb > 9)
        ft_putnbr(nb / 10);
    write(1, &(char){(nb % 10) + '0'}, 1);
}

void ft_print_comb2(void)
{
    int a = 0;
    int b;
    while (a < 99)
    {
        b = a + 1;
        while (b < 100)
        {
            if (a < 10)
                write(1, "0", 1);
            ft_putnbr(a);
            write(1, " ", 1);
            if (b < 10)
                write(1, "0", 1);
            ft_putnbr(b);
            if (!(a == 98 && b == 99))
                write(1, ", ", 2);
            b++;
        }
        a++;
    }
}

