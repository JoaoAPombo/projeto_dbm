def categorizar_idade(idade):
    """
    Classifica a pessoa com base na idade.

    :param idade: Idade da pessoa
    :return: Categoria da pessoa (Jovem, Adulto ou Sênior)
    """
    if idade < 30:
        return "Jovem"
    elif 30 <= idade <= 40:
        return "Adulto"
    else:
        return "Sênior"
