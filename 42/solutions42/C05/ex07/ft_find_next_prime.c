int IsPrime(int nb)
{
  if (nb == 0 || nb == 1)
    return 0;
  for (int i = 2; i < nb; i++)
  {
    if (nb % i == 0)
      return 0;
  }
  return 1;
}

int ft_find_next_prime(int nb)
{
  if (nb < 0)
    nb = 0;
  if (IsPrime(nb) == 1)
    return nb;
  else
  {
    while (IsPrime(nb) == 0)
      nb += 1;
    return nb;
  }
}
