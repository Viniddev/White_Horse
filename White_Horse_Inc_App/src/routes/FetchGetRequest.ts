import GetHeader from "./GetRequestHeader";

export async function fetchGetRequest( params: any, URL: string ): Promise<any> {
  var response: any = await fetch(URL, {
    method: "GET",
    headers: GetHeader(),
  });

  const data: Promise<any> = await response.json();
  return data;
}
