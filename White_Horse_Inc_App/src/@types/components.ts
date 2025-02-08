import { Endereco, UserInformations } from "./req";

export interface ProductCardInformations {
  title: string;
  subtitle: string;
  description: string;
  link: string;
  price: number;
  topic: number;
}

export interface CardProdutosProps {
  prop: ProductCardInformations; // Aqui declaramos a prop
}

export interface BuildInputText {
  state: string;
  setState: (value: string) => void;
  label: string;
  required: boolean;
  invalid: boolean;
}

export interface BuildInputNumber {
  state: number;
  setState: (value: number) => void;
  label: string;
  required: boolean;
}

export interface BuildInputCep {
  state: UserInformations;
  setState: React.Dispatch<React.SetStateAction<UserInformations>>;
  label: string;
  required: boolean;
  mask: string;
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
  required: boolean;
}

export interface BuildDefaultForm {
  IsRegister: boolean;
  DefaultUserInformations: UserInformations;
}

export interface Prop {
  list: Array<ProductCardInformations>;
  setList: (value: Array<ProductCardInformations>) => void;
}

export interface FiltroFormularioPrincipal {
  preco: number;
  nome: string;
  topico: Topico;
}

export interface Topico {
  name: string;
  code: number;
}

export interface TopicOptions {
  state: Topico;
  setState: (value: Topico) => void;
  list: Array<Topico>;
}