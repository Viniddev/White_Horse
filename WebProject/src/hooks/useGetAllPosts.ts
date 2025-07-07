import { IPagedRequest } from "@/@types/IPagedRequest";
import { IPostsInformations, IGetPostsResponse } from "@/@types/IPostsInformations";
import { fetchPutRequest } from "@/routes/FetchPutRequest";
import { GET_ALL_POSTS } from "@/utils/backEndUrls/urls";
import { Toast } from "primereact/toast";
import { useRef, useState, useEffect } from "react";

export default function getAllPosts(){
    const toast = useRef<Toast>(null);
    const [loading, setLoading] = useState(true);
    const [posts, setPosts] = useState<Array<IPostsInformations>>([]);

    async function getAllPosts() {
      setLoading(true);
      try {
        const pagedRequest: IPagedRequest = {
          PageNumber: 1,
          PageSize: 10,
        };

        var postsList: IGetPostsResponse = await fetchPutRequest(
          pagedRequest,
          GET_ALL_POSTS
        );

        if (postsList.data === null) {
          toast?.current?.show({
            severity: "error",
            summary: "Info",
            detail: postsList.message,
            life: 3500,
          });
          return;
        }

        setPosts(postsList.data);
      } catch (error) {
        toast?.current?.show({
          severity: "error",
          summary: "Erro",
          detail: "Falha ao carregar posts",
          life: 3500,
        });
      } finally {
        setLoading(false);
      }
    }

    useEffect(() => {
        getAllPosts();
    }, []);

    return {
      loading,
      posts,
      toast,
    };
}