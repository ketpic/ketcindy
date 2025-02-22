;; variation on runge-kutta (rk) routine in complex_dynamics.lisp by villate@fe.up.pt
;; this one with changed by fateman@berkeley.edu

#| rkfun may be much faster than rk because it calls compiled programs.
 rkfun (this file) should also be compiled to speed it up.
 how to use:


 first, read and understand the documentation for rk().
 next, define the ODE right hand sides as functions as shown below

fun1(y,x,x0):= x0$  
fun2(y,x,x0):= block([], mode_declare([y, x0,x],float),(1-x^2)*x0-x);
compile(fun1)$
compile(fun2)$
showtime:all$

last(rkfun([fun1,fun2],[x,xdot],[0.0,0.6],[t,0,50,0.01]));

/* which is, in one test, 18 times faster than */

last(rk([xdot,(1-x^2)*xdot -x],[x,xdot],[0.0,0.6],[t,0,50,0.01]));

|#

(defun $rkfun (funs vars initial domain ;; taken from complex_dynamics.lisp
            &aux d u funlist k1 k2 k3 k4 r1 r2 r3 traj r
              (it (mapcar #'coerce-float (cddr domain))))
  (unless ($listp funs) (setq funs `((mlist) ,funs)))
  (unless ($listp initial) (setq initial `((mlist) ,initial)))
  (unless ($listp vars) (setq vars `((mlist) ,vars)))
  (dolist (var (cdr vars))
    (unless (symbolp var)
      (merror (intl:gettext "rk: variable name expected; found: ~M") var)))
  (unless (symbolp (cadr domain))
    (merror (intl:gettext "rk: variable name expected; found: ~M")
            (cadr domain)))
  (setq vars (append '((mlist)) (list (cadr domain)) (cdr vars)))
  (setq r (append `(,(car it)) (mapcar #'coerce-float (cdr initial))))
  (setq funlist (cdr funs))
  
  (setq d (/ (- (cadr it) (car it)) (caddr it)))
  (setq traj (list (cons '(mlist) r)))
  (do ((m 1 (1+ m))) ((> m d))
    (progn ;;; was ignore-errors
      (setq k1 (mapcar #'(lambda (x) (apply x r)) funlist))
      (setq r1 (map 'list #'+ (cdr r) (mapcar #'(lambda (x) (* 0.5d0 (caddr it) x)) k1)))
      (push (+ (car r) (/ (caddr it) 2)) r1)
      (setq k2 (mapcar #'(lambda (x) (apply x r1)) funlist))
      (setq r2 (map 'list #'+ (cdr r) (mapcar #'(lambda (x) (* 0.5d0(caddr it) x)) k2)))
      (push (+ (car r) (/ (caddr it) 2)) r2)
      (setq k3 (mapcar #'(lambda (x) (apply x r2)) funlist))
      (setq r3 (map 'list #'+ (cdr r) (mapcar #'(lambda (x) (* (caddr it) x)) k3)))
      (push (+ (car r) (caddr it)) r3)
      (setq k4 (mapcar #'(lambda (x) (apply x r3)) funlist))
      (setq u (map 'list #'+
                   (mapcar #'(lambda (x) (* #.(/ 1.0 6.0d0) x)) k1)
                   (mapcar #'(lambda (x) (* #.(/ 1.0 3.0d0) x)) k2)
                   (mapcar #'(lambda (x) (* #.(/ 1.0 3.0d0) x)) k3)
                   (mapcar #'(lambda (x) (* #.(/ 1.0 6.0d0) x)) k4)))
      (setq r 
            (append
	     `(,(+ (car it) (* m (caddr it))))
	     (map 'list #'+ (cdr r) (mapcar #'(lambda (x) (* (caddr it) x)) u))))
      (push (cons '(mlist) r) traj)))
  (when (< (car r) (cadr it))
    (let ((s (- (cadr it) (car r))) )
      (declare(double-float s)(special s)(optimize (speed 3)(safety 0)))
      (progn ;; was ignore-errors
        (setq k1 (mapcar #'(lambda (x) (mapply x r nil)) funlist))
        (setq r1 (map 'list #'+ (cdr r) (mapcar #'(lambda (x)
						    (declare(double-float x))
						    (*  s 0.5d0 x)) k1)))
        (push (+ (car r) (* 0.5d0 s)) r1)
        (setq k2 (mapcar #'(lambda (x) (mapply x r1 nil)) funlist))
        (setq r2 (map 'list #'+ (cdr r) (mapcar #'(lambda (x)(declare(double-float x))
							  (*  s 0.5d0 x)) k2)))
        (push (+ (car r) (* 0.5d0 s)) r2)
        (setq k3 (mapcar #'(lambda (x) (mapply x r2 nil)) funlist))
        (setq r3 (map 'list #'+ (cdr r) (mapcar #'(lambda (x)(declare(double-float x))
							  (* s x)) k3)))
        (push (+ (car r) s) r3)
        (setq k4 (mapcar #'(lambda (x) (mapply x r3 nil)) funlist))
        (setq u (map 'list #'+
                     (mapcar #'(lambda (x)(declare(double-float x))
				       (* #.(/ 1.0d0 6.0d0) x)) k1)
                     (mapcar #'(lambda (x)(declare(double-float x))
				       (* #.(/ 1.0d0 3.0d0) x)) k2)
                     (mapcar #'(lambda (x) (declare(double-float x))
				       (* #.(/ 1.0d0 3.0d0) x)) k3)
                     (mapcar #'(lambda (x)(declare(double-float x))
				       (* #.(/ 1.0d0 6.0d0) x)) k4)))
        (setq r 
              (append
	       `(,(cadr it))
	       (map 'list #'+ (cdr r) (mapcar #'(lambda (x)(declare(double-float x))
							(* s x)) u))))
        (push (cons '(mlist) r) traj))))
  (cons '(mlist) (nreverse traj)))