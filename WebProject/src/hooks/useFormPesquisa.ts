import { ProductCardInformations, Topico } from "@/@types/components";

export function orderByAscendingFunction(Lista: Array<ProductCardInformations>) {
  return [...Lista].sort((a, b) => a.title.localeCompare(b.title));
}

export function orderByDescendingFunction(Lista: Array<ProductCardInformations>) {
  return [...Lista].sort((a, b) => b.title.localeCompare(a.title));
}

export function filtrarLista(lista: Array<ProductCardInformations>, filtro: { nome: string; preco: number; topico: Topico }): Array<ProductCardInformations> {
  return lista.filter((produto) => {
    const nomeValido = filtro.nome
      ? produto.title.toLowerCase().includes(filtro.nome.toLowerCase())
      : true;

    const precoValido = filtro.preco ? produto.price <= filtro.preco : true;

    const topicoValido = filtro.topico.code
      ? produto.topic === filtro.topico.code
      : true;

    return nomeValido && precoValido && topicoValido;
  });
}