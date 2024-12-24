#include <unistd.h>

void ft_print_hex(char c)
{
    char *hex = "0123456789abcdef";
    write(1, "\\", 1);
    write(1, &hex[c / 16], 1);
    write(1, &hex[c % 16], 1);
}


void ft_putstr_non_printable(char *str)
{
    unsigned int i = 0;
    while (str[i] != '\0')
    {
        if (str[i] >= 32 && str[i] <= 126)
            write(1, &str[i], 1);
        else
         ft_print_hex(str[i]);
        i++;
    }
}

int main(void)
{
    ft_putstr_non_printable("Coucou\a\nSalut\rCa va ?\f!");
}
