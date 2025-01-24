
export interface ProductCardInformations {
  title: string;
  subtitle: string;
  description: string;
  link: string;
}

export interface CardProdutosProps {
  prop: ProductCardInformations; // Aqui declaramos a prop
}

export interface BuildInputText {
  state: string;
  setState: React.Dispatch<React.SetStateAction<string>>;
  label:string;
}