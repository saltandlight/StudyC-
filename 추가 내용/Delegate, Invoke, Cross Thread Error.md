# Delegate, Invoke, Cross Thread Error

## Delegate

- 대리자 or 대리인
- 함수 포인터와 비슷한 개념
- 메서드의 포인터를 저장하기만 함
- 부모 윈도우와 자식(UserControl)와의 이벤트 전송에 종종 사용됨
  - 부모  윈도우 -> 자식(UserControl): 자연스러움
  - 자식(UserControl) ->부모  윈도우: 부자연스러움

- 참고 사이트: https://codepulse.tistory.com/26

## Invoke

- 다른 쓰레드에서 메인 쓰레드를 접근하려고 하는 것 방지하기 위해 존재
  - 예) 다른 쓰레드에서 UI쪽 접근하여 어떤 것을 바꾸려고 할 때
- 이것 없이 멀티스레드 돌리면 크로스 스레드 오류현상이 일어남
- Dispatcher.Invoke를 주로 사용함
- 참고 사이트: http://blog.naver.com/PostView.nhn?blogId=aorigin&logNo=100140073826

## 크로스 스레드 오류현상

- WPF에서는 UI Thread, Rendering Thread를 가지고 시작된다고 함
- 메인 쓰레드가 UI를 소유함(다른 쓰레드에서 접근 불가)
- '다른 쓰레드에서 메인 쓰레드 접근할 때 생기는 오류'
- 그래서.... 해결할 수 있는 방법은? 

## 크로스 스레드 오류 해결 방법

### 1. Dispatcher

- 해야할 작업 내용과 작업의 우선순위를 가지고 있는 큐
- UI 컨트롤은 DispatcherObject를 상속받고 있음
- DispatcherObject는 연관된 Dispatcher로만 접근 가능
- 다른 쓰레드에서 접근하려고 하면 다른 Dispatcher니까 런타임 에러 발생
- `targetControl.Dispatcher.BeginInvoke(우선순위, 델리게이트, 전달할 파라미터);`
  - targetControl 자리에 어떤 컨트롤도 올 수 있음

## 2. SynchronizationContext

참고 사이트: https://m.blog.naver.com/PostView.nhn?blogId=mim0520&logNo=221448604950&proxyReferer=https:%2F%2Fwww.google.com%2F