#include <stdio.h>

int length(char *str)
{
    int i = 0;
    while (str[i] != '\0')
        i++;
    return i;
}

int find_index_in_base(char c, char *base)
{
    int i = 0;
    while (base[i] != '\0')
    {
        if (base[i] == c)
            return i;
        i++;
    }
    return -1;
}

int check_base(char *base)
{
    if (length(base) <= 1)
        return 0;

    int i = 0;
    while (base[i] != '\0')
    {
        if (base[i] == '+' || base[i] == '-' || base[i] == ' ')
            return 0;
        for (int j = i + 1; base[j] != '\0'; j++)
            if (base[i] == base[j])
                return 0;
        i++;
    }
    return 1;
}

int str_to_int(char *str, char *base)
{
    int i = 0;
    int result = 0;
    int base_length = length(base);
    while (str[i] != '\0')
    {
        int index = find_index_in_base(str[i], base);
        if (index == -1)
            return 0;
        result = result * base_length + index;
        i++;
    }
    return result;
}

int ft_atoi_base(char *str, char *base)
{
    if (check_base(base) == 0)
         return 0;

    int i = 0;
    int sign = 1;
    while (str[i] == ' ')
        i++;
    while (str[i] == '+' || str[i] == '-')
    {
        if (str[i] == '-')
            sign *= -1;
        i++;
    }
    return str_to_int(&str[i], base) * sign;
}

int main()
{
    printf("%d\n", str_to_int("1011", "01"));
    printf("%d\n", str_to_int("-458457", "0123456789"));
    printf("%d\n", str_to_int("458457", "0123456789"));
    printf("%d", str_to_int("5E37", "0123456789ABCDEF"));
}
