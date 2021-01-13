# Generic(제네릭)
- 형식 매개변수인 T는 모든 데이터 형식을 대신할 수 있음
- 다른 클라이언트 코드에서 런타임 캐스팅 또는 boxing 작업에 대한 비용 발생하지 않고 단일 클래스 작성 가능
- ```C#
    class GenericList<T> where T : gClass
    {
        // 내용
    }
  ```
- 형식 제약 시 다음과 같이 사용함
    - `where 형식 매개변수 : 제약조건`
- where 절과 사용 가능한 제약 조건
    - `where T : struct` => T는 값 형식
    - `where T : class` => T는 참조 형식
    - `where T : new()` => T는 매개변수가 없는 생성자가 있어야 함
    - `where T : 부모 클래스 이름` => T는 부모 클래스의 자식 클래스여야 함
    - `where T : 인터페이스 이름` => T는 인터페이스를 반드시 구현해야 함, 여러 개의 인터페이스를 명시 가능
    - `where T : U` => T는 다른 형식 매개변수 U로부터 상속받은 클래스여야 함
- 참조 사이트: `https://qzqz.tistory.com/214` 