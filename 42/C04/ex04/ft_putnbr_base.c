#include <unistd.h>

unsigned int ft_unsigned_strlen(char *str)
{
    unsigned int length = 0;
    while (str[length] != 0)
        length++;
    return length;
}

void ft_putchar(char c)
{
    write(1, &c, 1);
}

void print_base(unsigned int nbr, char *base, unsigned int base_length)
{
    if (nbr >= base_length)
        print_base(nbr / base_length, base, base_length);
    ft_putchar(base[nbr % base_length]);
}

void ft_putnbr_base(int nbr, char *base)
{
    unsigned int base_length = ft_unsigned_strlen(base);
    if (base_length <= 1)
        return;

    for (unsigned int i = 0; i < base_length - 1; i++)
        for (unsigned int j = 0; j < base_length - 1; j++)
            if ((base[i] == base[j] && i != j) || base[j] == '-' || base[j] == '+')
                return;
    if (nbr == -2147483648)
    {
        ft_putchar('-');
        print_base((unsigned int)2147483648, base, base_length);
        return;
    }

    if (nbr < 0)
    {
        ft_putchar('-');
        nbr = -nbr;
    }

    print_base(nbr, base, base_length);
}
