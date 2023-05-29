export interface Response<T> {
  code: number;
  data: T;
  messages: string[];
}
