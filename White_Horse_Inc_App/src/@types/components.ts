
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
  setState: (value: string) => void;
  label: string;
}

export interface BuildInputNumber {
  state: number;
  setState: (value: number) => void;
  label: string;
}

export interface SidebarToggle {
  state: boolean;
  setState: React.Dispatch<React.SetStateAction<boolean>>;
}

export interface BuildMaskInput {
  state: string;
  setState: (value: string) => void;
  label: string;
  mask: string;
}

export interface BuildDefaultForm {
  IsRegister: boolean;
}