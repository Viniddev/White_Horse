import { UserInformations } from "@/@types/req";

export const EMPTY_USER: UserInformations = {
  id: 0,
  creationDate: "",
  name: "",
  cpf: "",
  rg: "",
  role: "",
  email: "",
  phoneNumber: "",
  password: "",
  address: {
    id: 0,
    creationDate: "",
    cep: "",
    street: "",
    neighborhood: "",
    city: "",
    number: 0,
  },
};

export const EMPTY_FILTRO_FORMULARIO_PRINCIPAL = {
  preco: 0,
  nome: "",
  topico: { name: "", code: 0 },
};