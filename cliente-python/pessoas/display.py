from pessoas.categorizar import categorizar_idade


def exibir_dados_pessoa(pessoa):
    """
    Exibe os dados da pessoa de forma organizada.

    :param pessoa: Dados da pessoa
    """
    if pessoa:
        print("Dados da Pessoa:")
        print(f"Nome: {pessoa['nome']}")
        print(f"Idade: {pessoa['idade']}")
        print(f"Cidade: {pessoa['cidade']}")
        print(f"Profissão: {pessoa['profissao']}")
        print(f"Categoria de Idade: {categorizar_idade(pessoa['idade'])}")
    else:
        print("Pessoa não encontrada.")
