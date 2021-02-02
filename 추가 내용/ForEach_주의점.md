# foreach 주의점
- while에는 컬렉션에 대한 제약이 없지만 foreach에서 대상이 되는 컬렉션을 변경하면 안 됨
- 만약 foreach 문 내에서 변경 시 다음과 같은 에러가 난다.
- ```C#
   처리되지 않은 예외: System.InvalidOperationException: 컬렉션이 수정되었습니다. 열거 작업이 실행되지 않을 수도 있습니다.   
   위치: System.ThrowHelper.ThrowInvalidOperationException(ExceptionResource resource)    
   위치: System.Collections.Generic.List`1.Enumerator.MoveNextRare()    
   위치: System.Collections.Generic.List`1.Enumerator.MoveNext()
  ```
- 해결방법
- 1. foreach에서 대상이 되는 컬렉션에서 ToList를 사용하여 변경(변경할 대상은 원본, foreach 위에서만 대상을 ToList로)
- 2. foreach를 for loop로 변경
- 3. while loop로 바꿔준다.
