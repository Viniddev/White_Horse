import { ProductCardInformations } from "@/@types/components";

export default function orderByDescendingFunction(Lista: Array<ProductCardInformations>) {
  return Lista.sort((a, b) => b.title.localeCompare(a.title));
}