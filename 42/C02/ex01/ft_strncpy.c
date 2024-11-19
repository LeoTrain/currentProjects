int ft_strlen(char *str)
{
    int length = 0;
    while (str[length] != '\0')
        length++;
    return length;
}

char *ft_strncpy(char *dest, char *src, unsigned int n)
{
    int srcLength = ft_strlen(src);
    for (int i = 0; i < (int)n; i++)
    {
        if (i <= srcLength)
            dest[i] = src[i];
        else
            dest[i] = '\0';
    }
    return dest;
}
