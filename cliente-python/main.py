from pessoas.api import buscar_pessoa_por_id
from pessoas.display import exibir_dados_pessoa
from pessoas.categorizar import categorizar_idade


def main():
    """
    Função principal que executa o programa.

    Solicita ao usuário o ID da pessoa, busca os dados da pessoa
    e exibe-os de forma organizada.
    """
    id_pessoa = input("Digite o ID da pessoa: ")
    pessoa = buscar_pessoa_por_id(id_pessoa)
    exibir_dados_pessoa(pessoa)


if __name__ == "__main__":
    main()
