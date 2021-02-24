# Lock과 동기화

## 1. 동기화

- 쓰레드들이 순서를 갖춰 자원을 사용하게 하는 것
- 중요한 점: 자원을 한 번에 하나의 쓰레드가 사용하게 하는 것

## 2. lock 키워드

- 지정된 개체에 대한 상호 배제 잠금 획득하여 명령문 블록 실행 후, 잠금 해제
- 잠금 유지되는 동안 잠금을 보유하는 쓰레드는 잠금을 다시 획득하고 해제 가능
- critical section을 한번에 하나의 쓰레드만 실행할 수 있도록 해줌
- lock() 의 파라미터에는 공유자원을 넣어줌
- lock(this)를 사용하는 경우 의도하지 않게 데드락 발생시키거나 Lock Granularity를 떨어뜨리는 부작용 야기할 수 있음
- Critical Section 코드 블록은 가능한 범위 작게 하는 것이 좋음(불필요한 부분만 Locking한다는 우너칙을 따름)
- 이런 경우 프로그램 성능이 떨어짐(왜냐하면 자원을 쥐고 있는 쓰레드를 다른 쓰레드가 기다려야 하니까) => 범위를 작게!
- 참조: `https://www.csharpstudy.com/Threads/lock.aspx`
- 참조: `https://docs.microsoft.com/ko-kr/dotnet/csharp/language-reference/keywords/lock-statement`
- 참조: `https://qzqz.tistory.com/258`

