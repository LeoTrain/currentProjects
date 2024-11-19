int ft_strncmp(char *s1, char *s2, unsigned int n)
{
    unsigned int i = 0;
    while (i < n && !(s1[i] == '\0' && s2[i] == '\0'))
    {
        if (s1[i] - s2[i] != 0)
            return s1[i] - s2[i];
        i++;
    }

    if (i < n)
        return s1[i] - s2[i];
    
    return 0;
}
