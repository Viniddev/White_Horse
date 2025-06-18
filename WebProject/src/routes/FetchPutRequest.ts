import GetHeader from "./GetRequestHeader";

export async function fetchPutRequest( params: any, URL: string ): Promise<any> {
  var response: any = await fetch(URL, {
    method: "PUT",
    headers: GetHeader(),
    body: JSON.stringify(params),
  });

  const data: Promise<any> = await response.json();
  return data;
}
