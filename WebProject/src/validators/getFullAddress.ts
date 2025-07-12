import { Endereco, UserInformations } from "@/@types/req";
import GetCepRequest from "@/routes/GetCepRequest";


export async function GetFullAddress(cep: string, setState:  React.Dispatch<React.SetStateAction<UserInformations>>){
  cep = cep.replace("_","").replace("-", "")
  
  if(cep.length == 8){
    var response: any = await GetCepRequest(cep);

    if (!response.erro) {
      var enderecoCompleto: Endereco = {
        id: '',
        creationDate: "",
        street: response.logradouro,
        cep: response.cep,
        neighborhood: response.bairro,
        city: response.localidade,
        number: 0,
      };
     
      setState((prevState) => ({
        ...prevState,
        address: enderecoCompleto,
      }));
    }
  }
}