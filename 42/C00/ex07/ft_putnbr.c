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
