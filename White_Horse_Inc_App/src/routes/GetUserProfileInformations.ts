import { GET_USER_INFORMATIONS } from "@/utils/backEndUrls/urls";
import GetHeader from "./GetRequestHeader";
import { UserInformations } from "@/@types/req";



export async function fetchUserProfileInformations( userId : string ): Promise<UserInformations> {

  var response: any = await fetch(GET_USER_INFORMATIONS, {
    method: "PUT",
    headers: GetHeader(),
    body: JSON.stringify({ Email: userId }),
  });

  const data: Promise<UserInformations> = await response.json();
  return data;
}
