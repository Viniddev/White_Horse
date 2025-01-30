import { Endereco, UserInformations } from "@/@types/req";
import PostRequest from "@/routes/postRequest";


export async function GetFullAddress(cep: string, setState:  React.Dispatch<React.SetStateAction<UserInformations>>){
  cep = cep.replace("_","").replace("-", "")
  
  if(cep.length == 8){
    var response: any = await PostRequest(cep);

    if (!response.erro) {
      var enderecoCompleto: Endereco = {
        rua: response.logradouro,
        cep: response.cep,
        bairro: response.bairro,
        cidade: response.localidade,
        numero: 0,
      };

      setState((prevState) => ({
        ...prevState,
        endereco: enderecoCompleto,
      }));
    }
  }
}