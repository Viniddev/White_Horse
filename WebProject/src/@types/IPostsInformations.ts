export interface IPostsInformations {
  id: string;
  creatorId: string;
  creatorName: string;
  content: string;
  topic: string;
  likes: number;
  deslikes: number;
}

export interface IGetPostsResponse {
  data: Array<IPostsInformations>;
  message: string;
};