import { VIACEP } from "@/utils/backEndUrls/urls";

export default async function GetCepRequest(param: any){
    var response: any = await fetch(VIACEP(param), {
      method: "GET",
    });

    const data: any = await response.json();
    return data;
}